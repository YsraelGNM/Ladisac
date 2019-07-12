Imports Microsoft.Practices.Unity
Imports System.IO

Public Class frmRptListaOTXMesXSemanaXAnio
    <Dependency()> _
    Public Property BCOrdenTrabajo As Ladisac.BL.IBCOrdenTrabajo
    <Dependency()> _
    Public Property BCGrupo As Ladisac.BL.IBCGrupo

    Dim query As String
    Dim ds As DataSet

    Private Sub frmRptListaOTXMesXSemanaXAnio_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ds = New DataSet
        query = BCGrupo.ListaGrupo
        Dim rea = New StringReader(query)
        ds.ReadXml(rea)
        cboGrupo.DisplayMember = "GRU_DESCRIPCION"
        cboGrupo.ValueMember = "GRU_ID"
        cboGrupo.DataSource = ds.Tables(0)
        cboGrupo.SelectedIndex = -1
        cboGrupo.TabIndex = 1
        btnVisualizar.TabIndex = 2
        cboGrupo.Focus()

    End Sub

    Private Sub btnVisualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVisualizar.Click
        Dim ds As New DataSet
        Dim query = BCOrdenTrabajo.ListaOTXMesXSemanaxAnio(dtpFecFin.Value.Year, CInt(cboGrupo.SelectedValue))
        Dim rea As New StringReader(query)
        Try
            ds.ReadXml(rea)
            ReportViewer1.LocalReport.DataSources.Clear()
            ReportViewer1.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("dsListaOTXMesXSemanaXAnio", ds.Tables(0)))
            'ReportViewer1.LocalReport.DataSources("dsListaKardex").Value.List.Table.Merge(ds.Tables(0)) 'Asi tambien funciona
            Dim parametro(1) As Microsoft.Reporting.WinForms.ReportParameter
            parametro(0) = New Microsoft.Reporting.WinForms.ReportParameter("Anio", dtpFecFin.Value.Date.Year)
            parametro(1) = New Microsoft.Reporting.WinForms.ReportParameter("Grupo", cboGrupo.SelectedValue.ToString)
            'parametro(2) = New Microsoft.Reporting.WinForms.ReportParameter("Sem", DatePart("ww", dtpFecFin.DateTime.Date))

            '' Añado uno o varios parámetros(En este caso solo uno al ReportViewer
            Me.ReportViewer1.LocalReport.SetParameters(parametro)
            ReportViewer1.RefreshReport()
        Catch ex As Exception

        End Try
    End Sub
End Class
