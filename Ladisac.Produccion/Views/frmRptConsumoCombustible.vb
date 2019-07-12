Imports Microsoft.Practices.Unity
Imports System.IO

Public Class frmRptConsumoCombustible
    <Dependency()> _
    Public Property BCHorno As Ladisac.BL.IBCHorno
    <Dependency()> _
    Public Property BCProduccion As Ladisac.BL.IBCProduccion

    Private Sub frmRptConsumoCombustible_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CargarHornos()
        cboHorno.SelectedIndex = 0
    End Sub

    Sub CargarHornos()
        Dim ds As New DataSet
        Dim query = BCHorno.ListaHorno
        Dim rea As New StringReader(query)
        ds.ReadXml(rea)
        With cboHorno
            .DisplayMember = "HOR_Descripcion"
            .ValueMember = "HOR_ID"
            .DataSource = ds.Tables(0)
        End With
    End Sub

    Private Sub btnVisualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVisualizar.Click
        Try
            ReportViewer1.LocalReport.DataSources.Clear()

            Dim ds, ds1, ds2 As New DataSet
            Dim query = BCProduccion.ListaCombustibleXQuemador(cboHorno.SelectedValue, dtpFecFin.Value.Date.Month, dtpFecFin.Value.Date.Year)
            Dim rea As New StringReader(query)
            ds.ReadXml(rea)

            query = BCProduccion.ListaCombustibleHorno(cboHorno.SelectedValue, dtpFecFin.Value.Date.Month, dtpFecFin.Value.Date.Year)
            rea = New StringReader(query)
            ds1.ReadXml(rea)

            query = BCProduccion.ConsumoR500PorDia(dtpFecFin.Value.Date)
            rea = New StringReader(query)
            ds2.ReadXml(rea)

            ReportViewer1.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("dsListaCombustibleXQuemador", ds.Tables(0)))
            ReportViewer1.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("dsListaCombustibleHorno", ds1.Tables(0)))
            ReportViewer1.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("dsConsumoR500PorDia", ds2.Tables(0)))
            'ReportViewer1.LocalReport.DataSources("dsListaKardex").Value.List.Table.Merge(ds.Tables(0)) 'Asi tambien funciona
            Dim parametro(1) As Microsoft.Reporting.WinForms.ReportParameter
            parametro(0) = New Microsoft.Reporting.WinForms.ReportParameter("horno", cboHorno.Text)
            parametro(1) = New Microsoft.Reporting.WinForms.ReportParameter("fecha", dtpFecFin.Value.Date)
            'parametro(2) = New Microsoft.Reporting.WinForms.ReportParameter("Sem", DatePart("ww", dtpFecFin.DateTime.Date))

            '' Añado uno o varios parámetros(En este caso solo uno al ReportViewer
            Me.ReportViewer1.LocalReport.SetParameters(parametro)
            ReportViewer1.RefreshReport()
        Catch ex As Exception

        End Try
    End Sub
End Class
