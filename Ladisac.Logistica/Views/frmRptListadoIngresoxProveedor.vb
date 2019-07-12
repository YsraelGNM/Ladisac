Imports Microsoft.Practices.Unity
Imports Ladisac.BE
Imports System.Windows.Forms
Imports System.IO
Public Class frmRptListadoIngresoxProveedor
    <Dependency()> _
    Public Property SessionServer As Ladisac.Foundation.Services.ISessionService
    <Dependency()> _
    Public Property BCDocuMovimiento As Ladisac.BL.IBCDocuMovimiento

    Private Sub frmRptListadoIngresoxProveedor_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtProveedor.TabIndex = 0
        txtArticulo.TabIndex = 1
        dtpFechaIni.TabIndex = 2
        dtpFechaFin.TabIndex = 3
        ckbMateriaPrima.TabIndex = 4
        btnCargar.TabIndex = 5
        txtProveedor.Focus()
    End Sub

    Private Sub btnCargar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCargar.Click
        Dim ds As New DataSet
        Dim query = BCDocuMovimiento.ListadoIngresoxProveedor(txtProveedor.Tag, txtArticulo.Tag, IIf(ckbMateriaPrima.Checked, "003", Nothing), dtpFechaIni.Value.Date, dtpFechaFin.Value.Date)
        If query <> "" Then
            Dim rea As New StringReader(query)
            ds.ReadXml(rea)
            ReportViewer1.LocalReport.DataSources.Clear()
            ReportViewer1.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("dsListadoIngresoxProveedor", ds.Tables(0)))
            Dim parametro(1) As Microsoft.Reporting.WinForms.ReportParameter
            parametro(0) = New Microsoft.Reporting.WinForms.ReportParameter("FechaIni", dtpFechaIni.Value.Date)
            parametro(1) = New Microsoft.Reporting.WinForms.ReportParameter("FechaFin", dtpFechaFin.Value.Date)
            Me.ReportViewer1.LocalReport.SetParameters(parametro)
            ReportViewer1.RefreshReport()
        Else
            ReportViewer1.LocalReport.DataSources.Clear()
            ReportViewer1.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("dsListadoIngresoxProveedor", New DataTable))
            Dim parametro(1) As Microsoft.Reporting.WinForms.ReportParameter
            parametro(0) = New Microsoft.Reporting.WinForms.ReportParameter("FechaIni", dtpFechaIni.Value.Date)
            parametro(1) = New Microsoft.Reporting.WinForms.ReportParameter("FechaFin", dtpFechaFin.Value.Date)
            Me.ReportViewer1.LocalReport.SetParameters(parametro)
            ReportViewer1.RefreshReport()
        End If
    End Sub

    Private Sub txtProveedor_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtProveedor.DoubleClick
        Dim frm = Me.ContainerService.Resolve(Of Ladisac.Logistica.Views.frmBuscar)()
        frm.Tabla = "Persona"
        frm.Tipo = "Proveedor"
        If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
            txtProveedor.Tag = frm.dgvLista.CurrentRow.Cells("PER_ID").Value 'Per_Id
            txtProveedor.Text = frm.dgvLista.CurrentRow.Cells(1).Value 'Nombres
        End If
        frm.Dispose()
    End Sub

    Private Sub txtArticulo_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtArticulo.DoubleClick
        Dim frm = Me.ContainerService.Resolve(Of Ladisac.Logistica.Views.frmBuscar)()
        frm.Tabla = "Articulo"

        If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
            txtArticulo.Tag = frm.dgvLista.CurrentRow.Cells(0).Value 'Per_Id
            txtArticulo.Text = frm.dgvLista.CurrentRow.Cells(1).Value 'Nombres
        End If
        frm.Dispose()
    End Sub

    Private Sub txtProveedor_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtProveedor.KeyDown
        If e.KeyCode = Keys.Enter Then txtProveedor_DoubleClick(Nothing, Nothing)
    End Sub

    Private Sub txtArticulo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtArticulo.KeyDown
        If e.KeyCode = Keys.Enter Then txtArticulo_DoubleClick(Nothing, Nothing)
    End Sub
End Class