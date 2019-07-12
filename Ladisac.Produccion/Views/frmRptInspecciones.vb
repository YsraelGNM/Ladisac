Imports Microsoft.Practices.Unity
Imports System.IO
Imports System.Windows.Forms

Public Class frmRptInspecciones
    <Dependency()> _
    Public Property BCProduccion As Ladisac.BL.IBCProduccion

    Private Sub frmRptInspecciones_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        txtLadrillo.TabIndex = 0
        txtIng1.TabIndex = 1
        txtProduccion.TabIndex = 2
        btnVisualizar.TabIndex = 3
        ReportViewer1.TabIndex = 4
    End Sub

    Private Sub txtProduccion_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtProduccion.DoubleClick
        Dim frm = Me.ContainerService.Resolve(Of Ladisac.Produccion.Views.frmBuscar)()
        frm.Tabla = "Produccion"
        If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
            txtProduccion.Tag = frm.dgvLista.CurrentRow.Cells(0).Value 'PRO_Id
            txtProduccion.Text = frm.dgvLista.CurrentRow.Cells(0).Value & " " & frm.dgvLista.CurrentRow.Cells("ART_DESCRIPCION").Value 'Nombres
        End If
        frm.Dispose()
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

    Private Sub txtIng1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtIng1.DoubleClick
        Dim frm = Me.ContainerService.Resolve(Of Ladisac.Produccion.Views.frmBuscar)()
        frm.Tabla = "Persona"
        frm.Tipo = "Trabajador"
        If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
            'CType(sender, TextBox).Tag = frm.dgvLista.CurrentRow.Cells(0).Value 'Per_Id
            'CType(sender, TextBox).Text = frm.dgvLista.CurrentRow.Cells(2).Value 'Nombres
            txtIng1.Tag = frm.dgvLista.CurrentRow.Cells(0).Value
            txtIng1.Text = frm.dgvLista.CurrentRow.Cells(2).Value
        End If
        frm.Dispose()
    End Sub

    Private Sub btnVisualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVisualizar.Click
        Try
            ReportViewer1.LocalReport.DataSources.Clear()

            Dim ds As New DataSet
            Dim query = BCProduccion.ReporteInspecciones(dtpFecIni.Value.Date, dtpFecFin.Value.Date, txtIng1.Tag, txtLadrillo.Tag, txtProduccion.Tag)
            Dim rea As New StringReader(query)
            ds.ReadXml(rea)

            ReportViewer1.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("dsReporteInspecciones", ds.Tables(0)))
            'ReportViewer1.LocalReport.DataSources("dsListaKardex").Value.List.Table.Merge(ds.Tables(0)) 'Asi tambien funciona
            Dim parametro(1) As Microsoft.Reporting.WinForms.ReportParameter
            parametro(0) = New Microsoft.Reporting.WinForms.ReportParameter("FecIni", dtpFecIni.Value.Date)
            parametro(1) = New Microsoft.Reporting.WinForms.ReportParameter("FecFin", dtpFecFin.Value.Date)
            'parametro(2) = New Microsoft.Reporting.WinForms.ReportParameter("Sem", DatePart("ww", dtpFecFin.DateTime.Date))

            '' Añado uno o varios parámetros(En este caso solo uno al ReportViewer
            Me.ReportViewer1.LocalReport.SetParameters(parametro)
            ReportViewer1.RefreshReport()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtProduccion_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtProduccion.KeyDown
        If e.KeyCode = Keys.Enter Then txtProduccion_DoubleClick(Nothing, Nothing)
    End Sub

    Private Sub txtLadrillo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtLadrillo.KeyDown
        If e.KeyCode = Keys.Enter Then txtLadrillo_DoubleClick(Nothing, Nothing)
    End Sub

    Private Sub txtIng1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtIng1.KeyDown
        If e.KeyCode = Keys.Enter Then txtIng1_DoubleClick(Nothing, Nothing)
    End Sub
End Class
