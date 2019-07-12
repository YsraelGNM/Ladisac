Imports Microsoft.Practices.Unity
Imports System.IO

Public Class frmRptHistoricoOrdenTrabajo
    <Dependency()> _
    Public Property BCEntidad As Ladisac.BL.IBCEntidad
    <Dependency()> _
    Public Property BCOT As Ladisac.BL.IBCOrdenTrabajo
    <Dependency()> _
    Public Property BCGrupo As Ladisac.BL.IBCGrupo
    Dim query As String
    Dim ds As DataSet

    Private Sub frmRptHistoricoOrdenTrabajo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ds = New DataSet
        query = BCGrupo.ListaGrupo
        Dim rea As New StringReader(query)
        rea = New StringReader(query)
        ds.ReadXml(rea)
        cboGrupo.DisplayMember = "GRU_DESCRIPCION"
        cboGrupo.ValueMember = "GRU_ID"
        cboGrupo.DataSource = ds.Tables(0)
        Me.ReportViewer1.RefreshReport()

        txtEntidad.TabIndex = 1
        cboGrupo.TabIndex = 2
        dtpFecIni.TabIndex = 3
        dtpFecFin.TabIndex = 4
        btnVisualizar.TabIndex = 5
        cboGrupo.SelectedIndex = -1
        txtEntidad.Focus()

    End Sub

    Private Sub txtEntidad_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtEntidad.DoubleClick
        Dim frm = Me.ContainerService.Resolve(Of Ladisac.Mantto.Views.frmBuscar)()
        frm.Tabla = "Entidad"
        If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
            txtEntidad.Tag = frm.dgvLista.CurrentRow.Cells(0).Value 'Eno_Id
            txtEntidad.Text = frm.dgvLista.CurrentRow.Cells(1).Value 'Descripcion
        End If
        frm.Dispose()
    End Sub

    Private Sub btnVisualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVisualizar.Click
        Dim ds As New DataSet
        '' '' ''Dim query = BCOT.ListaHistoricoOrdenTrabajo(txtEntidad.Tag, dtpFecIni.Value, dtpFecFin.Value, CInt(cboGrupo.SelectedValue))
        '' '' ''Dim rea As New StringReader(query)
        Try
            '' '' ''ds.ReadXml(rea)
            ds = InsertarTrabajos(txtEntidad.Tag)
            ReportViewer1.LocalReport.DataSources.Clear()
            ReportViewer1.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("dsListaHistoricoOT", ds.Tables(0)))
            'ReportViewer1.LocalReport.DataSources("dsListaKardex").Value.List.Table.Merge(ds.Tables(0)) 'Asi tambien funciona
            'Dim parametro(0) As Microsoft.Reporting.WinForms.ReportParameter
            'parametro(0) = New Microsoft.Reporting.WinForms.ReportParameter("Almacen", txtAlmacen.Text)
            'parametro(1) = New Microsoft.Reporting.WinForms.ReportParameter("FecFin", dtpFecFin.DateTime.Date)
            'parametro(2) = New Microsoft.Reporting.WinForms.ReportParameter("Sem", DatePart("ww", dtpFecFin.DateTime.Date))

            '' Añado uno o varios parámetros(En este caso solo uno al ReportViewer
            'Me.ReportViewer1.LocalReport.SetParameters(parametro)
            ReportViewer1.RefreshReport()
        Catch ex As Exception

        End Try
    End Sub

    Function InsertarTrabajos(ByVal Eno_Id As Integer) As DataSet
        Dim ds As New DataSet
        Dim query = BCOT.ListaHistoricoOrdenTrabajo(Eno_Id, dtpFecIni.Value, dtpFecFin.Value, CInt(cboGrupo.SelectedValue))
        If query.Length > 0 Then
            Dim rea As New StringReader(query)
            ds.ReadXml(rea)
            'For Each mItem In BCEntidad.ListaHijos(Eno_Id)
            '    Dim ds1 As DataSet
            '    ds1 = InsertarTrabajos(mItem.ENO_ID)
            '    ds.Merge(ds1)
            'Next
        End If
        Return ds
    End Function

    Private Sub txtEntidad_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtEntidad.KeyDown
        ' If e.KeyCode = Keys.Enter Then txtEntidad_DoubleClick(Nothing, Nothing)
        If e.KeyCode = Windows.Forms.Keys.Enter Then txtEntidad_DoubleClick(Nothing, Nothing)

    End Sub
End Class
