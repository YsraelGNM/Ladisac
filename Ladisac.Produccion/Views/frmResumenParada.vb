Imports Microsoft.Practices.Unity
Imports Ladisac.BE
Imports System.Windows.Forms
Imports System.IO

Public Class frmResumenParada
    <Dependency()> _
    Public Property BCProduccion As Ladisac.BL.IBCProduccion

    Private Sub frmResumenParada_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

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

    Private Sub txtLadrillo_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtLadrillo.DoubleClick
        Dim frm = Me.ContainerService.Resolve(Of Ladisac.Produccion.Views.frmBuscar)()
        frm.Tabla = "Ladrillo"
        If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
            txtLadrillo.Tag = frm.dgvLista.CurrentRow.Cells(0).Value
            txtLadrillo.Text = frm.dgvLista.CurrentRow.Cells(1).Value
        End If
        frm.Dispose()
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

            Dim ds As New DataSet
            If chkForma1.Checked Then
                Dim query = BCProduccion.ListaResumenParadasForma1(dtpFecIni.Value.Date, dtpFecFin.Value.Date, txtPlanta.Tag, txtLadrillo.Tag, IIf(chkSinPruebas.Checked, 1, 0), txtExtrusora.Tag)
                Dim rea As New StringReader(query)
                ds.ReadXml(rea)
            Else
                Dim query = BCProduccion.ListaResumenParadas(dtpFecIni.Value.Date, dtpFecFin.Value.Date, txtPlanta.Tag, txtLadrillo.Tag, IIf(chkSinPruebas.Checked, 1, 0), txtExtrusora.Tag)
                Dim rea As New StringReader(query)
                ds.ReadXml(rea)
            End If


            ReportViewer1.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("dsListaResumenParada", ds.Tables(0)))
            'ReportViewer1.LocalReport.DataSources("dsListaKardex").Value.List.Table.Merge(ds.Tables(0)) 'Asi tambien funciona
            Dim parametro(8) As Microsoft.Reporting.WinForms.ReportParameter
            parametro(0) = New Microsoft.Reporting.WinForms.ReportParameter("FecIni", dtpFecIni.Value.Date)
            parametro(1) = New Microsoft.Reporting.WinForms.ReportParameter("FecFin", dtpFecFin.Value.Date)
            parametro(2) = New Microsoft.Reporting.WinForms.ReportParameter("Planta", txtPlanta.Text)
            parametro(3) = New Microsoft.Reporting.WinForms.ReportParameter("Ladrillo", txtLadrillo.Text)
            parametro(4) = New Microsoft.Reporting.WinForms.ReportParameter("Mayor", numMayor.Value)
            parametro(5) = New Microsoft.Reporting.WinForms.ReportParameter("Menor", numMenor.Value)
            parametro(6) = New Microsoft.Reporting.WinForms.ReportParameter("Valor", numValor.Value)
            parametro(7) = New Microsoft.Reporting.WinForms.ReportParameter("Extrusora", txtExtrusora.Text)
            Dim Forma1 As String = IIf(chkForma1.Checked, "1", "0")
            parametro(8) = New Microsoft.Reporting.WinForms.ReportParameter("Forma1", Forma1)

            '' Añado uno o varios parámetros(En este caso solo uno al ReportViewer
            Me.ReportViewer1.LocalReport.SetParameters(parametro)
            ReportViewer1.RefreshReport()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
End Class
