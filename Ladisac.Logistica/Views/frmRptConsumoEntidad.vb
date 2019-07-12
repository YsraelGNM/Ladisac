Imports Microsoft.Practices.Unity
Imports System.IO

Public Class frmRptConsumoEntidad
    <Dependency()> _
    Public Property BCEntidad As Ladisac.BL.IBCEntidad
    <Dependency()> _
    Public Property BCMantto As Ladisac.BL.IBCMantto
    <Dependency()> _
    Public Property BCTipoClaseMantto As Ladisac.BL.IBCTipoClaseMantto
    <Dependency()> _
    Public Property BCGrupo As Ladisac.BL.IBCGrupo

    Dim query As String
    Dim ds As New DataSet

    Private Sub frmRptConsumoEntidad_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        llenarCbo()
        cboClaseMantto.SelectedIndex = -1
        cboGrupo.SelectedIndex = -1
        cboMantenimiento.SelectedIndex = -1
        Me.ReportViewer1.RefreshReport()
        txtEntidad.TabIndex = 0
        dtpFecIni.TabIndex = 1
        dtpFecFin.TabIndex = 2
        btnVisualizar.TabIndex = 3
        txtEntidad.Focus()
    End Sub

    Sub llenarCbo()
        Try
            ds = New DataSet
            query = BCMantto.ListaMantto()
            Dim rea As New StringReader(query)
            ds.ReadXml(rea)
            cboMantenimiento.DisplayMember = "MTO_DESCRIPCION"
            cboMantenimiento.ValueMember = "MTO_ID"
            cboMantenimiento.DataSource = ds.Tables(0)

            ds = New DataSet
            query = BCTipoClaseMantto.ListaTipoClaseMantto
            rea = New StringReader(query)
            ds.ReadXml(rea)
            cboClaseMantto.DisplayMember = "TCM_DESCRIPCION"
            cboClaseMantto.ValueMember = "TCM_ID"
            cboClaseMantto.DataSource = ds.Tables(0)

            ds = New DataSet
            query = BCGrupo.ListaGrupo
            rea = New StringReader(query)
            ds.ReadXml(rea)
            cboGrupo.DisplayMember = "GRU_DESCRIPCION"
            cboGrupo.ValueMember = "GRU_ID"
            cboGrupo.DataSource = ds.Tables(0)
        Catch ex As Exception

        End Try
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

    Private Sub txtOrdenTrabajo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtOrdenTrabajo.KeyDown
        If e.KeyCode = Keys.Enter Then txtOrdenTrabajo_DoubleClick(Nothing, Nothing)
    End Sub

    Private Sub txtEntidad_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtEntidad.DoubleClick
        Dim frm = Me.ContainerService.Resolve(Of Ladisac.Logistica.Views.frmBuscar)()
        frm.Tabla = "Entidad"
        If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
            txtEntidad.Tag = frm.dgvLista.CurrentRow.Cells(0).Value 'Eno_Id
            txtEntidad.Text = frm.dgvLista.CurrentRow.Cells(1).Value 'Descripcion
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
        Try
            ds = BCEntidad.ListaConsumoEntidad(txtEntidad.Tag, dtpFecIni.Value, dtpFecFin.Value, txtArticulo.Tag, txtOrdenTrabajo.Tag, cboMantenimiento.SelectedValue, cboClaseMantto.SelectedValue, cboGrupo.SelectedValue)
            
            ReportViewer1.LocalReport.DataSources.Clear()
            ReportViewer1.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("dsConsumoEntidad", ds.Tables(0)))
            'ReportViewer1.LocalReport.DataSources("dsListaKardex").Value.List.Table.Merge(ds.Tables(0)) 'Asi tambien funciona
            'Dim parametro(0) As Microsoft.Reporting.WinForms.ReportParameter
            'parametro(0) = New Microsoft.Reporting.WinForms.ReportParameter("Almacen", txtAlmacen.Text)
            'parametro(1) = New Microsoft.Reporting.WinForms.ReportParameter("FecFin", dtpFecFin.DateTime.Date)
            'parametro(2) = New Microsoft.Reporting.WinForms.ReportParameter("Sem", DatePart("ww", dtpFecFin.DateTime.Date))

            '' Añado uno o varios parámetros(En este caso solo uno al ReportViewer
            'Me.ReportViewer1.LocalReport.SetParameters(parametro)
            ReportViewer1.RefreshReport()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub txtEntidad_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtEntidad.KeyDown
        If e.KeyCode = Keys.Enter Then txtEntidad_DoubleClick(Nothing, Nothing)
    End Sub
End Class
