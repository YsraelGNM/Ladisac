Imports Microsoft.Practices.Unity
Imports System.IO

Public Class frmRptConsumoCombustible
    <Dependency()> _
    Public Property BCKardex As Ladisac.BL.IBCKardex

    Private Sub frmRptConsumoCombustible_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.ReportViewer1.RefreshReport()
        txtEmpresa.TabIndex = 0
        txtPlaca.TabIndex = 1
        dtpFecIni.TabIndex = 2
        dtpFecFin.TabIndex = 3
        btnVisualizar.TabIndex = 4
        ReportViewer1.TabIndex = 5
        ReportViewer1.TabIndex = 6
        txtEmpresa.Focus()

    End Sub

    Private Sub txtEmpresa_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtEmpresa.DoubleClick
        Dim frm = Me.ContainerService.Resolve(Of Ladisac.Logistica.Views.frmBuscar)()
        frm.Tabla = "Persona"
        frm.Tipo = "Proveedor"
        If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
            txtEmpresa.Tag = frm.dgvLista.CurrentRow.Cells("PER_ID").Value 'Per_Id
            txtEmpresa.Text = frm.dgvLista.CurrentRow.Cells(1).Value 'Descripcion
        End If
        frm.Dispose()
    End Sub

    Private Sub btnVisualizar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnVisualizar.Click
        Dim ds As New DataSet
        Dim query = BCKardex.ListaConsumoCombustible(txtEmpresa.Tag, txtPlaca.Text.Trim, CDate(dtpFecIni.Value.Date), CDate(dtpFecFin.Value.Date))
        Try
            Dim rea As New StringReader(query)

            ds.ReadXml(rea)

            ReportViewer1.LocalReport.DataSources.Clear()
            ReportViewer1.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("dsListaConsComb", ds.Tables(0)))
            'ReportViewer1.LocalReport.DataSources("dsListaKardex").Value.List.Table.Merge(ds.Tables(0)) 'Asi tambien funciona
            'Dim parametro(0) As Microsoft.Reporting.WinForms.ReportParameter
            'parametro(0) = New Microsoft.Reporting.WinForms.ReportParameter("Almacen", txtAlmacen.Text)
            'parametro(1) = New Microsoft.Reporting.WinForms.ReportParameter("FecFin", dtpFecFin.DateTime.Date)
            'parametro(2) = New Microsoft.Reporting.WinForms.ReportParameter("Sem", DatePart("ww", dtpFecFin.DateTime.Date))

            '' Añado uno o varios parámetros(En este caso solo uno al ReportViewer
            'Me.ReportViewer1.LocalReport.SetParameters(parametro)
            ReportViewer1.RefreshReport()
        Catch ex As Exception
            ReportViewer1.LocalReport.DataSources.Clear()
            ReportViewer1.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("dsListaConsComb", New DataTable))
            ReportViewer1.RefreshReport()
        End Try
    End Sub

    Private Sub txtPlaca_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPlaca.DoubleClick
        Dim frm = Me.ContainerService.Resolve(Of Ladisac.Logistica.Views.frmBuscar)()
        frm.Tabla = "UnidadesTransporteEmpresa"
        frm.Tipo = txtEmpresa.Tag

        If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
            txtPlaca.Tag = frm.dgvLista.CurrentRow.Cells(0).Value 'UNT_Id
            txtPlaca.Text = frm.dgvLista.CurrentRow.Cells(0).Value 'Descripcion
        End If
        frm.Dispose()
    End Sub

    Private Sub txtEmpresa_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtEmpresa.KeyDown
        If e.KeyCode = Keys.Enter Then txtEmpresa_DoubleClick(Nothing, Nothing)
    End Sub

    Private Sub txtPlaca_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPlaca.KeyDown
        If e.KeyCode = Keys.Enter Then txtPlaca_DoubleClick(Nothing, Nothing)
    End Sub
End Class
