Imports Microsoft.Practices.Unity
Imports System.IO
Public Class frmRptReporteTickets
    <Dependency()> _
    Public Property BCKardex As Ladisac.BL.IBCKardex

    Private Sub btnVisualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVisualizar.Click
        Dim ds As New DataSet
        Dim tipo As String

        If rbuTickets.Checked Then
            tipo = "004"
        ElseIf rbuVales.Checked Then
            tipo = "056"
        Else
            tipo = ""
        End If

        
        Dim query = BCKardex.ListaReporteTickets(txtEmpresa.Tag, tipo, dtpFecIni.Value, dtpFecFin.Value)
        If query.ToString.Length > 0 Then
            Dim rea As New StringReader(query)
            ds.ReadXml(rea)
        End If
        Try
            ReportViewer1.LocalReport.DataSources.Clear()
            ReportViewer1.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("dsReporteTickets", ds.Tables(0)))

            Dim parametro(2) As Microsoft.Reporting.WinForms.ReportParameter
            parametro(0) = New Microsoft.Reporting.WinForms.ReportParameter("FecIni", dtpFecIni.Value.Date)
            parametro(1) = New Microsoft.Reporting.WinForms.ReportParameter("FecFin", dtpFecFin.Value.Date)
            parametro(2) = New Microsoft.Reporting.WinForms.ReportParameter("Tipo", tipo)

            Me.ReportViewer1.LocalReport.SetParameters(parametro)
            ReportViewer1.RefreshReport()
        Catch ex As Exception
            MessageBox.Show("No hay data que mostrar.")
        End Try

    End Sub

    Private Sub frmRptReporteTickets_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtEmpresa.TabIndex = 0
        dtpFecIni.TabIndex = 1
        dtpFecFin.TabIndex = 2
        btnVisualizar.TabIndex = 3
        txtEmpresa.Focus()
    End Sub

    Private Sub txtEmpresa_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtEmpresa.DoubleClick
        Dim frm = Me.ContainerService.Resolve(Of Ladisac.Logistica.Views.frmBuscar)()
        frm.Tabla = "Persona"
        frm.Tipo = "Proveedor"
        If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
            txtEmpresa.Tag = frm.dgvLista.CurrentRow.Cells("PER_ID").Value 'Per_Id
            txtEmpresa.Text = frm.dgvLista.CurrentRow.Cells(1).Value 'Nombres
        End If
        frm.Dispose()
    End Sub

    Private Sub txtEmpresa_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtEmpresa.KeyDown
        If e.KeyCode = Keys.Enter Then txtEmpresa_DoubleClick(Nothing, Nothing)
    End Sub
End Class