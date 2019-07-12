Imports Microsoft.Practices.Unity
Imports System.IO
Imports System.Windows.Forms

Public Class frmRptAlertaCambios
    <Dependency()> _
    Public Property BCEntidad As Ladisac.BL.IBCEntidad

    Dim colR As Integer = -1
    Dim dsR As New DataSet

    Private Sub frmRptAlertaCambios_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Visualizar()
    End Sub

    Private Sub dgvDetalle_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvDetalle.CellClick
        colR = e.ColumnIndex
    End Sub

    Private Sub txtBuscarResumen_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtBuscarResumen.KeyDown
        If e.KeyCode = Keys.Down Then
            If dgvDetalle.CurrentRow.Index + 1 < dgvDetalle.Rows.Count - 1 Then dgvDetalle.CurrentCell = dgvDetalle.Rows(dgvDetalle.CurrentRow.Index + 1).Cells(colR)
        ElseIf e.KeyCode = Keys.Up Then
            If dgvDetalle.CurrentRow.Index - 1 > -1 Then dgvDetalle.CurrentCell = dgvDetalle.Rows(dgvDetalle.CurrentRow.Index - 1).Cells(colR)
        End If
    End Sub

    Private Sub txtBuscarResumen_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtBuscarResumen.TextChanged
        If colR = -1 Then colR = 0
        dgvDetalle.DataSource = SelectDataTableResumen(dsR.Tables(0), dgvDetalle.Columns(colR).Name & " like '%" & txtBuscarResumen.Text & "%'")
        If txtBuscarResumen.Text = "" Then dgvDetalle.DataSource = dsR.Tables(0)
        dgvDetalle.CurrentCell = dgvDetalle.Rows(0).Cells(colR)
    End Sub

    Public Shared Function SelectDataTableResumen(ByVal dt As DataTable, ByVal filter As String) As DataTable
        Dim rows As DataRow()
        Dim dtNew As DataTable

        dtNew = dt.Clone()
        rows = dt.Select(filter)
        For Each dr As DataRow In rows
            dtNew.ImportRow(dr)
        Next

        Return dtNew
    End Function

    Private Sub btnVisualizar_Click(sender As System.Object, e As System.EventArgs) Handles btnVisualizar.Click
        Visualizar()
    End Sub

    Sub Visualizar()
        Dim ds As New DataSet
        Dim query = BCEntidad.ListaAlertaCambios()
        Dim rea As New StringReader(query)
        ds.ReadXml(rea)
        Try
            dgvDetalle.DataSource = ds.Tables(0)
            ReportViewer1.LocalReport.DataSources.Clear()
            ReportViewer1.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("dsListaAlertaCambios", ds.Tables(0)))
            'ReportViewer1.LocalReport.DataSources("dsListaKardex").Value.List.Table.Merge(ds.Tables(0)) 'Asi tambien funciona
            'Dim parametro(0) As Microsoft.Reporting.WinForms.ReportParameter
            'parametro(0) = New Microsoft.Reporting.WinForms.ReportParameter("Almacen", txtAlmacen.Text)
            'parametro(1) = New Microsoft.Reporting.WinForms.ReportParameter("FecFin", dtpFecFin.DateTime.Date)
            'parametro(2) = New Microsoft.Reporting.WinForms.ReportParameter("Sem", DatePart("ww", dtpFecFin.DateTime.Date))

            '' Añado uno o varios parámetros(En este caso solo uno al ReportViewer
            'Me.ReportViewer1.LocalReport.SetParameters(parametro)
            ReportViewer1.RefreshReport()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
End Class
