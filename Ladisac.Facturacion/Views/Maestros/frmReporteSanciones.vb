Imports Microsoft.Practices.Unity
Imports System.IO
Imports System.Windows.Forms
Imports System.Data

Public Class frmReporteSanciones
    <Dependency()> _
    Public Property BCSancion As Ladisac.BL.IBCSancion

    Private Sub frmReporteSanciones_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load


    End Sub

    Private Sub txtNombresFalta_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtNombresFalta.DoubleClick
        Dim frm = Me.ContainerService.Resolve(Of Ladisac.Despacho.Views.frmBuscar)()
        frm.Tabla = "Persona"
        frm.Tipo = "Trabajador"
        If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
            txtNombresFalta.Tag = frm.dgvLista.CurrentRow.Cells("Per_Id").Value 'Per_Id
            txtNombresFalta.Text = frm.dgvLista.CurrentRow.Cells(2).Value 'Nombres
        End If
        frm.Dispose()
    End Sub


    Private Sub txtNombresFalta_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtNombresFalta.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtNombresFalta_DoubleClick(Nothing, Nothing)
        End If
    End Sub

    'Private Sub txtUNT_Id_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtUNT_Id.DoubleClick
    '    Dim frm = Me.ContainerService.Resolve(Of Ladisac.Despacho.Views.frmBuscar)()
    '    frm.Tabla = "Placa"
    '    If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
    '        txtUNT_Id.Tag = frm.dgvLista.CurrentRow.Cells(0).Value 'UNT_Id
    '        txtUNT_Id.Text = frm.dgvLista.CurrentRow.Cells(0).Value 'UNT_Id
    '    End If
    '    frm.Dispose()
    'End Sub


    'Private Sub txtUNT_Id_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtUNT_Id.KeyDown
    '    If e.KeyCode = Keys.Enter Then
    '        txtUNT_Id_DoubleClick(Nothing, Nothing)
    '    End If
    'End Sub

    Private Sub txtPer_Id_Proveedor_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPer_Id_Proveedor.DoubleClick
        Dim frm = Me.ContainerService.Resolve(Of Ladisac.Despacho.Views.frmBuscar)()
        frm.Tabla = "Persona"
        frm.Tipo = "Proveedor"
        If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
            txtPer_Id_Proveedor.Tag = frm.dgvLista.CurrentRow.Cells("Per_Id").Value 'Per_Id
            txtPer_Id_Proveedor.Text = frm.dgvLista.CurrentRow.Cells(1).Value 'Nombres
        End If
        frm.Dispose()
    End Sub


    Private Sub txtPer_Id_Proveedor_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPer_Id_Proveedor.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtPer_Id_Proveedor_DoubleClick(Nothing, Nothing)
        End If
    End Sub


    Private Sub btnVisualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVisualizar.Click
        Try
            Dim ds As New DataSet
            Dim query = BCSancion.ListaControlSanciones(dtpFecIni.Value, dtpFecFin.Value, txtNombresFalta.Tag, txtDNI.Text, txtPer_Id_Proveedor.Tag, txtUNT_Id.Text)
            If query.ToString.Length > 0 Then
                Dim rea As New StringReader(query)
                ds.ReadXml(rea)
            End If
            ReportViewer1.LocalReport.DataSources.Clear()
            ReportViewer1.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("dsListaControlSanciones", ds.Tables(0)))

            'Dim parametro(2) As Microsoft.Reporting.WinForms.ReportParameter
            'parametro(0) = New Microsoft.Reporting.WinForms.ReportParameter("FecIni", dtpFecIni.Value.Date)
            'parametro(1) = New Microsoft.Reporting.WinForms.ReportParameter("FecFin", dtpFecFin.Value.Date)
            'parametro(2) = New Microsoft.Reporting.WinForms.ReportParameter("Tipo", tipo)
            'Me.ReportViewer1.LocalReport.SetParameters(parametro)

            ReportViewer1.RefreshReport()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
End Class
