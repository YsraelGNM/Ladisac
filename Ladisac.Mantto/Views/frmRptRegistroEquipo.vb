Imports Microsoft.Practices.Unity
Imports System.IO
Imports System.Windows.Forms

Public Class frmRptRegistroEquipo
    <Dependency()> _
    Public Property BCRegEquipo As Ladisac.BL.IBCRegistroEquipo

    Private Sub frmRptRegistroEquipo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cargarArea(cboArea)
        cargarTurno(cboTurno)
        Me.ReportViewer1.RefreshReport()
    End Sub

    Private Sub txtMaquina_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtMaquina.DoubleClick
        Dim frm = Me.ContainerService.Resolve(Of Ladisac.Mantto.Views.frmBuscar)()
        frm.Tabla = "Entidad"
        If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
            txtMaquina.Tag = frm.dgvLista.CurrentRow.Cells(0).Value
            txtMaquina.Text = frm.dgvLista.CurrentRow.Cells(1).Value
        End If
        frm.Dispose()
    End Sub

    Private Sub txtOperador_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtOperador.DoubleClick
        Dim frm = Me.ContainerService.Resolve(Of Ladisac.Mantto.Views.frmBuscar)()
        frm.Tabla = "Persona"
        frm.Tipo = "Trabajador"
        If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
            txtOperador.Tag = frm.dgvLista.CurrentRow.Cells(0).Value
            txtOperador.Text = frm.dgvLista.CurrentRow.Cells(2).Value
        End If
        frm.Dispose()
    End Sub

    Private Sub txtUbicacion_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtUbicacion.DoubleClick
        Dim frm = Me.ContainerService.Resolve(Of Ladisac.Mantto.Views.frmBuscar)()
        frm.Tabla = "UbicacionTrabajo"
        If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
            txtUbicacion.Tag = frm.dgvLista.CurrentRow.Cells(2).Value
            txtUbicacion.Text = frm.dgvLista.CurrentRow.Cells(1).Value
        End If
        frm.Dispose()
    End Sub

    Private Sub txtTarea_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTarea.DoubleClick
        Dim frm = Me.ContainerService.Resolve(Of Ladisac.Mantto.Views.frmBuscar)()
        frm.Tabla = "Tarea"
        If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
            txtTarea.Tag = frm.dgvLista.CurrentRow.Cells(0).Value
            txtTarea.Text = frm.dgvLista.CurrentRow.Cells(1).Value
        End If
        frm.Dispose()
    End Sub

    Public Sub CargarArea(ByVal cboArea As ComboBox)
        Dim ds As New DataSet
        Dim query = BCRegEquipo.ListaArea
        Dim rea As StringReader
        rea = New StringReader(query)
        ds.ReadXml(rea)

        With cboArea
            .DisplayMember = "ARE_Descripcion"
            .ValueMember = "Codigo"
            .DataSource = ds.Tables(0)
            .SelectedIndex = -1
        End With
    End Sub

    Public Sub CargarTurno(ByVal cboTurne As ComboBox)
        Dim strTurno As String() = {"", "Mañana", "Tarde"}
        cboTurne.DataSource = strTurno
    End Sub

    Private Sub btnVisualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVisualizar.Click
        Dim ds As New DataSet
        Dim query = BCRegEquipo.ReporteRegistroEquipo(dtpFecIni.Value.Date, dtpFecFin.Value.Date, CInt(cboArea.SelectedValue), CInt(txtTarea.Tag), CInt(txtMaquina.Tag), txtOperador.Tag, CInt(txtUbicacion.Tag), CInt(cboTurno.SelectedIndex))
        Dim rea As New StringReader(query)

        If query.ToString.Length > 0 Then
            ds.ReadXml(rea)
        End If

        Try
            ReportViewer1.LocalReport.DataSources.Clear()
            ReportViewer1.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("dsReporteRegistroEquipo", ds.Tables(0)))
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

    Private Sub txtOperador_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtOperador.KeyDown
        If e.KeyCode = Keys.Enter Then txtOperador_DoubleClick(Nothing, Nothing)
    End Sub

    Private Sub txtTarea_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtTarea.KeyDown
        If e.KeyCode = Keys.Enter Then txtTarea_DoubleClick(Nothing, Nothing)
    End Sub

    Private Sub txtMaquina_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtMaquina.KeyDown
        If e.KeyCode = Keys.Enter Then txtMaquina_DoubleClick(Nothing, Nothing)
    End Sub

    Private Sub txtUbicacion_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtUbicacion.KeyDown
        If e.KeyCode = Keys.Enter Then txtUbicacion_DoubleClick(Nothing, Nothing)
    End Sub
End Class