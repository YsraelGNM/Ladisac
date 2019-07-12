Imports Microsoft.Practices.Unity
Imports System.IO
Imports System.Windows.Forms

Public Class frmReporteBrutoNetoMateriaPrima
    <Dependency()> _
    Public Property BCProduccion As Ladisac.BL.IBCProduccion
    <Dependency()> _
    Public Property BCTipoProduccion As Ladisac.BL.IBCTipoProduccion

    Private Sub frmReporteBrutoNetoMateriaPrima_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CargarTipoProduccion()
        Me.ReportViewer1.RefreshReport()
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

    Private Sub btnVisualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVisualizar.Click
        Try
            ReportViewer1.LocalReport.DataSources.Clear()

            Dim mds As New DataSet
            For Each mFila As DataGridViewRow In dgvTipoProduccion.Rows
                If mFila.Cells("Mostrar").Value = True Then
                    Dim ds As New DataSet
                    Dim query = BCProduccion.ReporteBrutoNetoMateriaPrima(dtpFecIni.Value.Date, dtpFecFin.Value.Date, IIf(txtPlanta.Tag IsNot Nothing, CInt(txtPlanta.Tag), Nothing), CInt(mFila.Cells("TPR_ID").Value), IIf(txtExtrusora.Tag IsNot Nothing, CInt(txtExtrusora.Tag), Nothing), IIf(rbtTodas.Checked, Nothing, IIf(rbtFinalizadas.Checked, True, False)), txtLadrillo.Tag)
                    If Not query = "" Then
                        Dim rea As New StringReader(query)
                        ds.ReadXml(rea)
                    Else
                        ds.Tables.Add(New DataTable)
                    End If

                    If mds.Tables.Count = 0 Then mds.Merge(ds) Else mds.Tables(0).Merge(ds.Tables(0))
                End If
            Next

            ReportViewer1.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("dsReporteBrutoNetoMateriaPrima", mds.Tables(0)))
            Dim parametro(4) As Microsoft.Reporting.WinForms.ReportParameter
            Dim mB As Boolean = Not chkBruto.Checked
            Dim mR As Boolean = Not chkReciclaje.Checked
            Dim mN As Boolean = Not chkNeto.Checked
            Dim mP As Boolean = Not chkPorcentaje.Checked
            Dim mCP As Boolean = Not chkCP.Checked
            parametro(0) = New Microsoft.Reporting.WinForms.ReportParameter("Bruto", mB)
            parametro(1) = New Microsoft.Reporting.WinForms.ReportParameter("Reciclaje", mR)
            parametro(2) = New Microsoft.Reporting.WinForms.ReportParameter("Neto", mN)
            parametro(3) = New Microsoft.Reporting.WinForms.ReportParameter("Porcentaje", mP)
            parametro(4) = New Microsoft.Reporting.WinForms.ReportParameter("CP", mCP)
            '' Añado uno o varios parámetros(En este caso solo uno al ReportViewer
            ReportViewer1.LocalReport.SetParameters(parametro)
            ReportViewer1.RefreshReport()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub ReportViewer1_ReportRefresh(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ReportViewer1.ReportRefresh
        Dim parametro(4) As Microsoft.Reporting.WinForms.ReportParameter
        Dim mB As Boolean = Not chkBruto.Checked
        Dim mR As Boolean = Not chkReciclaje.Checked
        Dim mN As Boolean = Not chkNeto.Checked
        Dim mP As Boolean = Not chkPorcentaje.Checked
        Dim mCP As Boolean = Not chkCP.Checked
        parametro(0) = New Microsoft.Reporting.WinForms.ReportParameter("Bruto", mB)
        parametro(1) = New Microsoft.Reporting.WinForms.ReportParameter("Reciclaje", mR)
        parametro(2) = New Microsoft.Reporting.WinForms.ReportParameter("Neto", mN)
        parametro(3) = New Microsoft.Reporting.WinForms.ReportParameter("Porcentaje", mP)
        parametro(4) = New Microsoft.Reporting.WinForms.ReportParameter("CP", mCP)
        '' Añado uno o varios parámetros(En este caso solo uno al ReportViewer
        ReportViewer1.LocalReport.SetParameters(parametro)
    End Sub
End Class
