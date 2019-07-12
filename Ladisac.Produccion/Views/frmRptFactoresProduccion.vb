Imports Microsoft.Practices.Unity
Imports Ladisac.BE
Imports System.Windows.Forms
Imports System.IO

Public Class frmRptFactoresProduccion
    <Dependency()> _
    Public Property BCProduccion As Ladisac.BL.IBCProduccion

    Private Sub frmRptFactoresProduccion_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load


    End Sub

    Private Sub txtPlanta_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPlanta.DoubleClick
        Dim frm = Me.ContainerService.Resolve(Of Ladisac.Produccion.Views.frmBuscar)()
        frm.Tabla = "Planta"
        If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
            txtPlanta.Tag = frm.dgvLista.CurrentRow.Cells(0).Value
            txtPlanta.Text = frm.dgvLista.CurrentRow.Cells(1).Value
        End If
        frm.Dispose()
    End Sub

    Private Sub btnVisualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVisualizar.Click
        Select Case TabControl1.SelectedIndex
            Case 0
                Try
                    Dim ds As New DataSet
                    Dim ds2 As New DataSet
                    Dim query = BCProduccion.FactoresProduccion(dtpFecIni.Value.Date)
                    Dim query2 = BCProduccion.FactoresProduccionSecadero(dtpFecIni.Value.Date)
                    Dim rea As New StringReader(query)
                    Dim rea2 As New StringReader(query2)
                    ds.ReadXml(rea)
                    ds2.ReadXml(rea2)


                    ReportViewer1.LocalReport.DataSources.Clear()
                    ReportViewer1.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("dsFactoresProduccion", ds.Tables(0)))
                    ReportViewer1.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("dsFactoresProduccionSecadero", ds2.Tables(0)))
                    Dim parametro(0) As Microsoft.Reporting.WinForms.ReportParameter
                    parametro(0) = New Microsoft.Reporting.WinForms.ReportParameter("Fecha", dtpFecIni.Value.Date)
                    Me.ReportViewer1.LocalReport.SetParameters(parametro)
                    ReportViewer1.RefreshReport()

                Catch ex As Exception
                    ReportViewer1.LocalReport.DataSources.Clear()
                    ReportViewer1.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("dsFactoresProduccion", New DataTable))
                    ReportViewer1.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("dsFactoresProduccionSecadero", New DataTable))
                    Dim parametro(0) As Microsoft.Reporting.WinForms.ReportParameter
                    parametro(0) = New Microsoft.Reporting.WinForms.ReportParameter("Fecha", dtpFecIni.Value.Date)
                    Me.ReportViewer1.LocalReport.SetParameters(parametro)
                    ReportViewer1.RefreshReport()
                End Try
            Case 1
                Try
                    Dim ds As New DataSet
                    Dim query = BCProduccion.FactoresProduccionResumen(dtpFecIni.Value.Date, dtpFecFin.Value.Date, txtPlanta.Tag)
                    Dim rea As New StringReader(query)
                    ds.ReadXml(rea)

                    ReportViewer2.LocalReport.DataSources.Clear()
                    ReportViewer2.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("dsFactoresProduccionResumen", ds.Tables(0)))
                    Dim parametro(1) As Microsoft.Reporting.WinForms.ReportParameter
                    parametro(0) = New Microsoft.Reporting.WinForms.ReportParameter("FecIni", dtpFecIni.Value.Date)
                    parametro(1) = New Microsoft.Reporting.WinForms.ReportParameter("FecFin", dtpFecFin.Value.Date)
                    Me.ReportViewer2.LocalReport.SetParameters(parametro)
                    ReportViewer2.RefreshReport()

                Catch ex As Exception
                    ReportViewer2.LocalReport.DataSources.Clear()
                    ReportViewer2.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("dsFactoresProduccionResumen", New DataTable))
                    Dim parametro(1) As Microsoft.Reporting.WinForms.ReportParameter
                    parametro(0) = New Microsoft.Reporting.WinForms.ReportParameter("FecIni", dtpFecIni.Value.Date)
                    parametro(1) = New Microsoft.Reporting.WinForms.ReportParameter("FecFin", dtpFecFin.Value.Date)
                    Me.ReportViewer2.LocalReport.SetParameters(parametro)
                    ReportViewer2.RefreshReport()
                End Try
            Case 2
                Try
                    Dim ds As New DataSet
                    Dim query = BCProduccion.SalidaVagonXDia(dtpFecIni.Value.Date, dtpFecFin.Value.Date)
                    Dim rea As New StringReader(query)
                    ds.ReadXml(rea)

                    ReportViewer3.LocalReport.DataSources.Clear()
                    ReportViewer3.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("dsReporteSalidaVagonXDia", ds.Tables(0)))
                    Dim parametro(1) As Microsoft.Reporting.WinForms.ReportParameter
                    parametro(0) = New Microsoft.Reporting.WinForms.ReportParameter("FecIni", dtpFecIni.Value.Date)
                    parametro(1) = New Microsoft.Reporting.WinForms.ReportParameter("FecFin", dtpFecFin.Value.Date)
                    Me.ReportViewer3.LocalReport.SetParameters(parametro)
                    ReportViewer3.RefreshReport()

                Catch ex As Exception
                    ReportViewer3.LocalReport.DataSources.Clear()
                    ReportViewer3.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("dsReporteSalidaVagonXDia", New DataTable))
                    Dim parametro(1) As Microsoft.Reporting.WinForms.ReportParameter
                    parametro(0) = New Microsoft.Reporting.WinForms.ReportParameter("FecIni", dtpFecIni.Value.Date)
                    parametro(1) = New Microsoft.Reporting.WinForms.ReportParameter("FecFin", dtpFecFin.Value.Date)
                    Me.ReportViewer3.LocalReport.SetParameters(parametro)
                    ReportViewer3.RefreshReport()
                End Try
        End Select
        

    End Sub

End Class