Imports Microsoft.Practices.Unity
Imports System.IO

Public Class frmRptListadoOrdenRequerimiento
    <Dependency()> _
    Public Property BCOrdenRequerimiento As Ladisac.BL.IBCOrdenRequerimiento
    <Dependency()> _
    Public Property BCGrupo As Ladisac.BL.IBCGrupo
    Dim query As String
    Dim ds As DataSet

    Private Sub frmRptListadoOrdenRequerimiento_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ds = New DataSet
        query = BCGrupo.ListaGrupo
        Dim rea As New StringReader(query)
        rea = New StringReader(query)
        ds.ReadXml(rea)
        cboGrupo.DisplayMember = "GRU_DESCRIPCION"
        cboGrupo.ValueMember = "GRU_ID"
        cboGrupo.DataSource = ds.Tables(0)
        cboGrupo.SelectedIndex = -1

        dtpFecIni.TabIndex = 0
        dtpFecFin.TabIndex = 1
        rbtTodas.TabIndex = 2
        rbtPendientes.TabIndex = 3
        rbtAtendidas.TabIndex = 4
        txtOrdenTrabajo.TabIndex = 5
        cboImportancia.TabIndex = 6
        cboGrupo.TabIndex = 7
        btnVisualizar.TabIndex = 8
        dtpFecIni.Focus()
    End Sub

    Private Sub txtOrdenTrabajo_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtOrdenTrabajo.DoubleClick
        Dim frm = Me.ContainerService.Resolve(Of Ladisac.Logistica.Views.frmBuscar)()
        frm.Tabla = "OrdenTrabajo"
        If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
            txtOrdenTrabajo.Tag = frm.dgvLista.CurrentRow.Cells(0).Value 'OTR_Id
            txtOrdenTrabajo.Text = frm.dgvLista.CurrentRow.Cells(1).Value 'Descripcion
        End If
        frm.Dispose()
    End Sub

    Private Sub btnVisualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVisualizar.Click
        Try



            Dim ds As New DataSet
            Dim query = BCOrdenRequerimiento.ListadoOrdenRequerimiento(dtpFecIni.Value, dtpFecFin.Value, cboImportancia.SelectedIndex, txtOrdenTrabajo.Tag, IIf(rbtAtendidas.Checked, 3, IIf(rbtPendientes.Checked, 2, 1)), cboGrupo.SelectedValue)
            Dim rea As New StringReader(query)
            ds.ReadXml(rea)


            ReportViewer1.LocalReport.DataSources.Clear()
            ReportViewer1.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("dsListadoOrdenRequerimiento", ds.Tables(0)))
            'ReportViewer1.LocalReport.DataSources("dsListaKardex").Value.List.Table.Merge(ds.Tables(0)) 'Asi tambien funciona
            Dim parametro(1) As Microsoft.Reporting.WinForms.ReportParameter
            parametro(0) = New Microsoft.Reporting.WinForms.ReportParameter("FecIni", dtpFecIni.Value.Date)
            parametro(1) = New Microsoft.Reporting.WinForms.ReportParameter("FecFin", dtpFecFin.Value.Date)
            '' Añado uno o varios parámetros(En este caso solo uno al ReportViewer
            Me.ReportViewer1.LocalReport.SetParameters(parametro)
            ReportViewer1.RefreshReport()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtOrdenTrabajo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtOrdenTrabajo.KeyDown
        If e.KeyCode = Keys.Enter Then txtOrdenTrabajo_DoubleClick(Nothing, Nothing)
    End Sub
End Class
