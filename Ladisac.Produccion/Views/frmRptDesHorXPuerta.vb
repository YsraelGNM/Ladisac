Imports Microsoft.Practices.Unity
Imports System.IO

Public Class frmRptDesHorXPuerta
    <Dependency()> _
    Public Property BCHorno As Ladisac.BL.IBCHorno
    <Dependency()> _
    Public Property BCProduccion As Ladisac.BL.IBCProduccion

    Private Sub frmRptDesHorXPuerta_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CargarHornos()
        cboHorno.SelectedIndex = -1
        Me.ReportViewer1.RefreshReport()
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
            Dim ds As New DataSet
            Dim query = BCProduccion.ListaDesHorXPuerta(dtpFecFin.Value, cboHorno.SelectedValue)
            Dim rea As New StringReader(query)
            ds.ReadXml(rea)

            ReportViewer1.LocalReport.DataSources.Clear()
            ReportViewer1.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("dsListaDesHorXPuerta", ds.Tables(0)))
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
