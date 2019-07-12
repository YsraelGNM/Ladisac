Imports Microsoft.Practices.Unity
Imports System.IO
Imports System.Windows.Forms

Public Class frmRptReporteFinalProduccion
    <Dependency()> _
    Public Property BCProduccion As Ladisac.BL.IBCProduccion
    <Dependency()> _
    Public Property BCTipoProduccion As Ladisac.BL.IBCTipoProduccion

    Private Sub frmRptReporteFinalProduccion_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CargarTipoProduccion()
        Me.ReportViewer5.RefreshReport()
    End Sub

    Sub CargarTipoProduccion()
        Dim ds As New DataSet
        Dim query = BCTipoProduccion.ListaTipoProduccion
        Dim rea As New StringReader(query)
        ds.ReadXml(rea)
        For Each mItem As DataRow In ds.Tables(0).Rows
            Dim nRow As New DataGridViewRow
            dgvTipoProduccion.Rows.Add(nRow)
            dgvTipoProduccion.Rows(dgvTipoProduccion.Rows.Count - 1).Cells("TPR_ID").Value = mItem.Item("TPR_ID")
            dgvTipoProduccion.Rows(dgvTipoProduccion.Rows.Count - 1).Cells("TPR_Descripcion").Value = mItem.Item("TPR_Descripcion")
            dgvTipoProduccion.Rows(dgvTipoProduccion.Rows.Count - 1).Cells("Mostrar").Value = False
        Next
    End Sub

    Private Sub txtExtrusora_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtExtrusora.DoubleClick
        Dim frm = Me.ContainerService.Resolve(Of Ladisac.Produccion.Views.frmBuscar)()
        frm.Tabla = "Extrusora"
        If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
            txtExtrusora.Tag = frm.dgvLista.CurrentRow.Cells(0).Value
            txtExtrusora.Text = frm.dgvLista.CurrentRow.Cells(1).Value
        End If
        frm.Dispose()
    End Sub

    Private Sub txtExtrusora_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtExtrusora.KeyDown
        If e.KeyCode = Keys.Enter Then txtExtrusora_DoubleClick(Nothing, Nothing)
    End Sub

    Private Sub btnVisualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVisualizar.Click
        Try
            ReportViewer1.LocalReport.DataSources.Clear()
            ReportViewer2.LocalReport.DataSources.Clear()
            ReportViewer3.LocalReport.DataSources.Clear()
            ReportViewer4.LocalReport.DataSources.Clear()
            ReportViewer5.LocalReport.DataSources.Clear()

            If TabControl1.SelectedIndex = 0 Or TabControl1.SelectedIndex = 1 Or TabControl1.SelectedIndex = 2 Or TabControl1.SelectedIndex = 3 Then

                Dim mds As New DataSet
                Dim mds1 As New DataSet
                For Each mFila As DataGridViewRow In dgvTipoProduccion.Rows
                    If mFila.Cells("Mostrar").Value = True Then
                        Dim ds As New DataSet
                        Dim query = BCProduccion.ReporteFinalProduccionDiario(dtpFecIni.Value.Date, dtpFecFin.Value.Date, IIf(txtPlanta.Tag IsNot Nothing, CInt(txtPlanta.Tag), Nothing), CInt(mFila.Cells("TPR_ID").Value), IIf(txtExtrusora.Tag IsNot Nothing, CInt(txtExtrusora.Tag), Nothing), IIf(rbtTodas.Checked, Nothing, IIf(rbtFinalizadas.Checked, True, False)), txtLadrillo.Tag)
                        If Not query = "" Then
                            Dim rea As New StringReader(query)
                            ds.ReadXml(rea)
                        Else
                            ds.Tables.Add(New DataTable)
                        End If

                        Dim ds1 As New DataSet
                        Dim query1 = BCProduccion.ReporteFinalProduccionFinalizada(dtpFecIni.Value.Date, dtpFecFin.Value.Date, IIf(txtPlanta.Tag IsNot Nothing, CInt(txtPlanta.Tag), Nothing), CInt(mFila.Cells("TPR_ID").Value), IIf(txtExtrusora.Tag IsNot Nothing, CInt(txtExtrusora.Tag), Nothing), IIf(rbtTodas.Checked, Nothing, IIf(rbtFinalizadas.Checked, True, False)))
                        If Not query1 = "" Then
                            Dim rea1 As New StringReader(query1)
                            ds1.ReadXml(rea1)
                        Else
                            ds1.Tables.Add(New DataTable)
                        End If

                        If mds.Tables.Count = 0 Then mds.Merge(ds) Else mds.Tables(0).Merge(ds.Tables(0))
                        If mds1.Tables.Count = 0 Then mds1.Merge(ds1) Else mds1.Tables(0).Merge(ds1.Tables(0))
                    End If
                Next

                dgvDetalle.DataSource = mds.Tables(0)
                dgvDetalle.Columns("CantidadMalos").DisplayIndex = 7

                ReportViewer1.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("dsReporteFinalProduccion", mds.Tables(0)))
                ReportViewer2.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("dsReporteFinalProduccion", mds.Tables(0)))
                ReportViewer2.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("dsReporteFinalProduccionFinalizada", mds1.Tables(0)))
                ReportViewer3.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("dsReporteFinalProduccion", mds.Tables(0)))
                ReportViewer5.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("dsReporteFinalProduccion", mds.Tables(0)))
                'ReportViewer1.LocalReport.DataSources("dsListaKardex").Value.List.Table.Merge(ds.Tables(0)) 'Asi tambien funciona
                Dim parametro(2) As Microsoft.Reporting.WinForms.ReportParameter
                parametro(0) = New Microsoft.Reporting.WinForms.ReportParameter("FecIni", dtpFecIni.Value.Date)
                parametro(1) = New Microsoft.Reporting.WinForms.ReportParameter("FecFin", dtpFecFin.Value.Date)
                parametro(2) = New Microsoft.Reporting.WinForms.ReportParameter("Planta", txtPlanta.Text)

                '' Añado uno o varios parámetros(En este caso solo uno al ReportViewer
                Me.ReportViewer2.LocalReport.SetParameters(parametro)
                ReportViewer1.RefreshReport()
                ReportViewer2.RefreshReport()
                ReportViewer3.RefreshReport()
                ReportViewer5.RefreshReport()

            ElseIf TabControl1.SelectedIndex = 4 Then

                Dim mds As New DataSet
                Dim mds1 As New DataSet
                For Each mFila As DataGridViewRow In dgvTipoProduccion.Rows
                    If mFila.Cells("Mostrar").Value = True Then
                        Dim ds As New DataSet
                        Dim query = BCProduccion.ReporteFinalProduccion(dtpFecIni.Value.Date, dtpFecFin.Value.Date, IIf(txtPlanta.Tag IsNot Nothing, CInt(txtPlanta.Tag), Nothing), CInt(mFila.Cells("TPR_ID").Value), IIf(txtExtrusora.Tag IsNot Nothing, CInt(txtExtrusora.Tag), Nothing), IIf(rbtTodas.Checked, Nothing, IIf(rbtFinalizadas.Checked, True, False)))
                        If Not query = "" Then
                            Dim rea As New StringReader(query)
                            ds.ReadXml(rea)
                        Else
                            ds.Tables.Add(New DataTable)
                        End If

                        Dim ds1 As New DataSet
                        Dim query1 = BCProduccion.ReporteFinalProduccionFinalizada(dtpFecIni.Value.Date, dtpFecFin.Value.Date, IIf(txtPlanta.Tag IsNot Nothing, CInt(txtPlanta.Tag), Nothing), CInt(mFila.Cells("TPR_ID").Value), IIf(txtExtrusora.Tag IsNot Nothing, CInt(txtExtrusora.Tag), Nothing), IIf(rbtTodas.Checked, Nothing, IIf(rbtFinalizadas.Checked, True, False)))
                        If Not query1 = "" Then
                            Dim rea1 As New StringReader(query1)
                            ds1.ReadXml(rea1)
                        Else
                            ds1.Tables.Add(New DataTable)
                        End If

                        If mds.Tables.Count = 0 Then mds.Merge(ds) Else mds.Tables(0).Merge(ds.Tables(0))
                        If mds1.Tables.Count = 0 Then mds1.Merge(ds1) Else mds1.Tables(0).Merge(ds1.Tables(0))
                    End If
                Next


                dgvDetalle.DataSource = mds.Tables(0)
                ReportViewer1.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("dsReporteFinalProduccion", mds.Tables(0)))
                ReportViewer2.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("dsReporteFinalProduccion", mds.Tables(0)))
                ReportViewer2.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("dsReporteFinalProduccionFinalizada", mds1.Tables(0)))
                ReportViewer3.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("dsReporteFinalProduccion", mds.Tables(0)))
                'ReportViewer1.LocalReport.DataSources("dsListaKardex").Value.List.Table.Merge(ds.Tables(0)) 'Asi tambien funciona
                Dim parametro(2) As Microsoft.Reporting.WinForms.ReportParameter
                parametro(0) = New Microsoft.Reporting.WinForms.ReportParameter("FecIni", dtpFecIni.Value.Date)
                parametro(1) = New Microsoft.Reporting.WinForms.ReportParameter("FecFin", dtpFecFin.Value.Date)
                parametro(2) = New Microsoft.Reporting.WinForms.ReportParameter("Planta", txtPlanta.Text)

                '' Añado uno o varios parámetros(En este caso solo uno al ReportViewer
                Me.ReportViewer2.LocalReport.SetParameters(parametro)
                ReportViewer1.RefreshReport()
                ReportViewer2.RefreshReport()
                ReportViewer3.RefreshReport()

            ElseIf TabControl1.SelectedIndex = 5 Then

                Dim mds As New DataSet
                For Each mFila As DataGridViewRow In dgvTipoProduccion.Rows
                    If mFila.Cells("Mostrar").Value = True Then
                        Dim ds As New DataSet
                        Dim query = BCProduccion.ReporteFinalProduccionComparativo(dtpFecIni.Value.Date, dtpFecFin.Value.Date, IIf(txtPlanta.Tag IsNot Nothing, CInt(txtPlanta.Tag), Nothing), CInt(mFila.Cells("TPR_ID").Value), IIf(txtExtrusora.Tag IsNot Nothing, CInt(txtExtrusora.Tag), Nothing))
                        If Not query = "" Then
                            Dim rea As New StringReader(query)
                            ds.ReadXml(rea)
                        Else
                            ds.Tables.Add(New DataTable)
                        End If
                        If mds.Tables.Count = 0 Then mds.Merge(ds) Else mds.Tables(0).Merge(ds.Tables(0))
                    End If
                Next

                ReportViewer4.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("dsReporteFinalProduccionComparativo", mds.Tables(0)))
                'ReportViewer1.LocalReport.DataSources("dsListaKardex").Value.List.Table.Merge(ds.Tables(0)) 'Asi tambien funciona
                'Dim parametro(2) As Microsoft.Reporting.WinForms.ReportParameter
                'parametro(0) = New Microsoft.Reporting.WinForms.ReportParameter("FecIni", dtpFecIni.Value.Date)
                'parametro(1) = New Microsoft.Reporting.WinForms.ReportParameter("FecFin", dtpFecFin.Value.Date)
                'parametro(2) = New Microsoft.Reporting.WinForms.ReportParameter("Planta", txtPlanta.Text)

                '' Añado uno o varios parámetros(En este caso solo uno al ReportViewer
                'Me.ReportViewer2.LocalReport.SetParameters(parametro)
                ReportViewer4.RefreshReport()
            End If
        Catch ex As Exception

        End Try
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

    Private Sub txtPlanta_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPlanta.KeyDown
        If e.KeyCode = Keys.Enter Then txtPlanta_DoubleClick(Nothing, Nothing)
    End Sub

    Private Sub txtLadrillo_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtLadrillo.DoubleClick
        Dim frm = Me.ContainerService.Resolve(Of Ladisac.Produccion.Views.frmBuscar)()
        frm.Tabla = "Ladrillo"
        If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
            txtLadrillo.Tag = frm.dgvLista.CurrentRow.Cells(0).Value
            txtLadrillo.Text = frm.dgvLista.CurrentRow.Cells(1).Value
        End If
        frm.Dispose()
    End Sub

    Private Sub txtLadrillo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtLadrillo.KeyDown
        If e.KeyCode = Keys.Enter Then txtLadrillo_DoubleClick(Nothing, Nothing)
    End Sub
End Class
