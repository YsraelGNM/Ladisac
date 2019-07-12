Imports Microsoft.Practices.Unity
Imports System.IO

Namespace Ladisac.Logistica.Views

    Public Class frmRptListaSaldoXAlmacen
        <Dependency()> _
        Public Property BCKardex As Ladisac.BL.IBCKardex

        Private Sub frmRptListaSaldoXAlmacen_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            txtAlmacen.TabIndex = 0
            txtArticulo.TabIndex = 1
            dtpFecIni.TabIndex = 2
            btnVisualizar.TabIndex = 3
            txtAlmacen.Focus()
        End Sub

        Private Sub txtAlmacen_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtAlmacen.DoubleClick
            Dim frm = Me.ContainerService.Resolve(Of Ladisac.Logistica.Views.frmBuscar)()
            frm.Tabla = "Almacen"
            If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
                txtAlmacen.Tag = frm.dgvLista.CurrentRow.Cells(0).Value 'Alm_Id
                txtAlmacen.Text = frm.dgvLista.CurrentRow.Cells(1).Value 'Descripcion
            End If
            frm.Dispose()
        End Sub

        Private Sub txtArticulo_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtArticulo.DoubleClick
            Dim frm = Me.ContainerService.Resolve(Of Ladisac.Logistica.Views.frmBuscar)()
            frm.Tabla = "Articulo"
            If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
                txtArticulo.Tag = frm.dgvLista.CurrentRow.Cells(0).Value 'Art_Id
                txtArticulo.Text = frm.dgvLista.CurrentRow.Cells(2).Value 'Descripcion
            End If
            frm.Dispose()
        End Sub

        Private Sub btnVisualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVisualizar.Click
            Dim ds As New DataSet
            Dim query = BCKardex.ListaSaldoXAlmacen(txtArticulo.Tag, txtAlmacen.Tag, dtpFecIni.Value)
            Dim rea As New StringReader(query)
            ds.ReadXml(rea)
            Try
                ReportViewer1.LocalReport.DataSources.Clear()
                ReportViewer1.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("dsListaSaldoXAlmacen", ds.Tables(0)))
                'ReportViewer1.LocalReport.DataSources("dsListaKardex").Value.List.Table.Merge(ds.Tables(0)) 'Asi tambien funciona
                Dim parametro(1) As Microsoft.Reporting.WinForms.ReportParameter
                parametro(0) = New Microsoft.Reporting.WinForms.ReportParameter("Fecha", dtpFecIni.Value.Date)
                parametro(1) = New Microsoft.Reporting.WinForms.ReportParameter("Almacen", txtAlmacen.Text.ToString)
                'parametro(2) = New Microsoft.Reporting.WinForms.ReportParameter("Sem", DatePart("ww", dtpFecFin.DateTime.Date))

                ' Añado uno o varios parámetros(En este caso solo uno al ReportViewer
                Me.ReportViewer1.LocalReport.SetParameters(parametro)
                ReportViewer1.RefreshReport()
            Catch ex As Exception
                ReportViewer1.LocalReport.DataSources.Clear()
                ReportViewer1.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("dsListaSaldoXAlmacen", New DataTable()))
                ReportViewer1.RefreshReport()
            End Try
        End Sub

        Private Sub txtAlmacen_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtAlmacen.KeyDown
            If e.KeyCode = Keys.Enter Then txtAlmacen_DoubleClick(Nothing, Nothing)
        End Sub

        Private Sub txtArticulo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtArticulo.KeyDown
            If e.KeyCode = Keys.Enter Then txtArticulo_DoubleClick(Nothing, Nothing)
        End Sub
    End Class

End Namespace
