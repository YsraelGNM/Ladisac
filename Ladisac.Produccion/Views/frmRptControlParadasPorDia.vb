Imports Microsoft.Practices.Unity
Imports System.IO

Public Class frmRptControlParadasPorDia
    <Dependency()> _
    Public Property BCProduccion As Ladisac.BL.IBCProduccion

    Private Sub frmRptControlParadasPorDia_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.ReportViewer1.RefreshReport()
    End Sub

    Private Sub btnVisualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVisualizar.Click
        Dim ds As New DataSet
        Dim ds1 As New DataSet
        Try
            If chkForma1.Checked Then
                Dim query = BCProduccion.ListaControlParadasPorDiaForma1(dtpFecFin.Value)
                Dim rea As New StringReader(query)
                ds.ReadXml(rea)
            Else
                Dim query = BCProduccion.ListaControlParadasPorDia(dtpFecFin.Value)
                Dim rea As New StringReader(query)
                ds.ReadXml(rea)
            End If
            


            Dim query1 = BCProduccion.ListaResumenControlParadasPorDia(dtpFecFin.Value)
            Dim rea1 As New StringReader(query1)
            ds1.ReadXml(rea1)

            ReportViewer1.LocalReport.DataSources.Clear()
            ReportViewer1.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("dsListaCtrlParadasXDia", ds.Tables(0)))
            ReportViewer1.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("dsListaResumenControlParadaPorDia", ds1.Tables(0)))
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
